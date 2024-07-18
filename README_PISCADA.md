# Build
gcc pipeme.c stats_post.c -o pipeme `pkg-config --cflags --libs gstreamer-1.0` -lcurl