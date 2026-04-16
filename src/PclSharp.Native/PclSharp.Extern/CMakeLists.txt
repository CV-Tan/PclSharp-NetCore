cmake_minimum_required(VERSION 3.15)
project(PclSharp.Extern CXX)

# ------------------------------
# Collect source files
# ------------------------------
file(GLOB_RECURSE EXTERN_SOURCES
    "common/*.cpp"
    "features/*.cpp"
    "filters/*.cpp"
    "io/*.cpp"
    "pointcloud/*.cpp"
    "registration/*.cpp"
    "sampleconsensus/*.cpp"
    "search/*.cpp"
    "segmentation/*.cpp"
    "surface/*.cpp"
    "PointSizes.cpp"
)

# ------------------------------
# Create shared library
# ------------------------------
add_library(PclSharp.Extern SHARED ${EXTERN_SOURCES})

# ------------------------------
# Include directories
# ------------------------------
target_include_directories(PclSharp.Extern PRIVATE
    ${PCL_INCLUDE_DIRS}
    ${VTK_INCLUDE_DIRS}
    ${Boost_INCLUDE_DIRS}
)

# ------------------------------
# Link libraries
# ------------------------------
target_link_libraries(PclSharp.Extern PRIVATE
    ${PCL_LIBRARIES}
    ${VTK_LIBRARIES}
    ${Boost_LIBRARIES}
)

# ------------------------------
# Set output directories
# ------------------------------
set_target_properties(PclSharp.Extern PROPERTIES
    RUNTIME_OUTPUT_DIRECTORY "${CMAKE_BINARY_DIR}/bin"
    LIBRARY_OUTPUT_DIRECTORY "${CMAKE_BINARY_DIR}/bin"
    ARCHIVE_OUTPUT_DIRECTORY "${CMAKE_BINARY_DIR}/lib"
)

# ------------------------------
# Windows-specific: VTK 9 autoinit
# ------------------------------
if(WIN32)
    vtk_module_autoinit(
        TARGETS PclSharp.Extern
        MODULES ${VTK_LIBRARIES}
    )
endif()
