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
find_package(VTK 9 REQUIRED)
# Add compile definitions from original project
add_definitions(${PCL_DEFINITIONS})

# Add subdirectories for each project
add_subdirectory(PclSharp.Extern)
add_subdirectory(PclSharp.ExternVis)