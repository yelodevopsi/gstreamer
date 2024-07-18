#include <stdio.h>
#include <curl/curl.h>
#include "stats_post.h"

void sendPostRequest(PostFields postFields, const char *statTypeStr, const char *hostname, const char *cameraID)
{
    CURL *hnd = curl_easy_init();

    if (hnd)
    {
        char url[256];
        snprintf(url, sizeof(url), "http://%s:9997/v3/gst/stats/%s/%s", hostname, statTypeStr, cameraID);

        curl_easy_setopt(hnd, CURLOPT_CUSTOMREQUEST, "POST");
        curl_easy_setopt(hnd, CURLOPT_URL, url);

        struct curl_slist *headers = NULL;
        headers = curl_slist_append(headers, "Content-Type: application/json");
        curl_easy_setopt(hnd, CURLOPT_HTTPHEADER, headers);

        char postfields[512];
        switch (postFields.statType)
        {
        case RTP_SOURCE:
            snprintf(postfields, sizeof(postfields), "{\n    \"packetsLost\": %d,\n    \"packetsReceived\": %lu,\n    \"bitrate\": %lu,\n    \"jitter\": %u\n  }",
                     postFields.stats.rtpSourceStats.packetsLost,
                     postFields.stats.rtpSourceStats.packetsReceived,
                     postFields.stats.rtpSourceStats.bitrate,
                     postFields.stats.rtpSourceStats.jitter);
            break;
        case JITTER_BUFFER:
            snprintf(postfields, sizeof(postfields), "{\n    \"numLost\": %lu,\n    \"numLate\": %lu,\n    \"numDuplicates\": %lu,\n    \"avgJitter\": %lu,\n    \"rtxCount\": %lu,\n    \"rtxSuccessCount\": %lu,\n    \"rtxPerPacket\": %f,\n    \"rtxRtt\": %lu\n  }",
                     postFields.stats.jitterBufferStats.numLost,
                     postFields.stats.jitterBufferStats.numLate,
                     postFields.stats.jitterBufferStats.numDuplicates,
                     postFields.stats.jitterBufferStats.avgJitter,
                     postFields.stats.jitterBufferStats.rtxCount,
                     postFields.stats.jitterBufferStats.rtxSuccessCount,
                     postFields.stats.jitterBufferStats.rtxPerPacket,
                     postFields.stats.jitterBufferStats.rtxRtt);
            break;
        case RTP_SESSION:
            snprintf(postfields, sizeof(postfields), "{\n    \"rtxDropCount\": %lu,\n    \"sentNackCount\": %lu,\n    \"recvNackCount\": %lu\n  }",
                     postFields.stats.rtpSessionStats.rtxDropCount,
                     postFields.stats.rtpSessionStats.sentNackCount,
                     postFields.stats.rtpSessionStats.recvNackCount);
            break;
        }

        curl_easy_setopt(hnd, CURLOPT_POSTFIELDS, postfields);

        CURLcode ret = curl_easy_perform(hnd);

        // Check for errors
        if (ret != CURLE_OK)
        {
            fprintf(stderr, "curl_easy_perform() failed: %s\n", curl_easy_strerror(ret));
        }

        // Always cleanup
        curl_easy_cleanup(hnd);
    }
    else
    {
        fprintf(stderr, "Failed to initialize CURL\n");
    }
}
