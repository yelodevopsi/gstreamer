# Production

## Docker

## Windows binary
Install only the runtime gstreamer from https://gstreamer.freedesktop.org/download/#windows

# Development

### Build on Ubuntu/Linux - for Linux binary and docker

1. Install all apt-packages needed + libcurl
2. MISSING HERE
3. Build in gcc by using:

```bash
# build
gcc pipeme.c stats_post.c -o pipeme `pkg-config --cflags --libs gstreamer-1.0` -lcurl
```

## Build on Windows

### Prerequisites  

Install both the **runtime** an **development** .msi packages from gstreamer from official site:

https://gstreamer.freedesktop.org/download/#windows

- Choose between MINGW or MSVC

## Visual Studio 2022 : MSVC

2. Ensure env var GSTREAMER_1_0_ROOT_X86_64 exists
3. Open Visual Studio (Community 2022) project gst-pipe.vcxproj
4.

## MSYS2/MINGW64

```bash (git bash in Windows)
# Requires MSYS/MING64 to be installed

pacman -Syu
pacman -S gcc pkg-config mingw-w64-x86_64-gstreamer mingw-w64-x86_64-curl

```

```powershell
# Set env in Powershell
$env:PKG_CONFIG_PATH="C:\gstreamer\1.0\mingw_x86_64\lib\pkgconfig"
```

```bash
# Build
gcc pipeme.c stats_post.c -o pipeme $(pkg-config --cflags --libs gstreamer-1.0) -lcurl

```
