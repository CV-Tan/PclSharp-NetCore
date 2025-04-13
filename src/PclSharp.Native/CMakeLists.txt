cmake_minimum_required(VERSION 3.18)
project(PclSharp.Native)

# Set C++ standard
set(CMAKE_CXX_STANDARD 14)
set(CMAKE_CXX_STANDARD_REQUIRED ON)

# Build type
if(NOT CMAKE_BUILD_TYPE)
    set(CMAKE_BUILD_TYPE Release)
endif()

# Find required packages
find_package(PCL 1.12.1 REQUIRED)
find_package(VTK 9.0 REQUIRED)
find_package(Boost 1.65 REQUIRED COMPONENTS system filesystem thread date_time iostreams serialization chrono atomic regex)
find_package(OpenNI2 REQUIRED)
find_package(FLANN REQUIRED)
find_package(Qhull REQUIRED)

# Add compile definitions from original project
add_definitions(
    -DWIN32
    -D__SSSE3__
    -D__SSE2__
    -D__SSE__
    -DBOOST_ALL_NO_LIB
    -DDISABLE_OPENNI
    -DDISABLE_ENSENSO
    -DDISABLE_DAVIDSDK
    -DDISABLE_DSSDK
    -DDISABLE_RSSDK
    -DDISABLE_PCAP
    -DDISABLE_PNG
    -DFLANN_STATIC
)

# Add subdirectories for each project
add_subdirectory(PclSharp.Extern)
add_subdirectory(PclSharp.ExternVis)