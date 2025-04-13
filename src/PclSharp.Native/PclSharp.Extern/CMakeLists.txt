# Collect source files
file(GLOB_RECURSE EXTERN_SOURCES
    "common/*.cpp"
    "eigen/*.cpp"
    "features/*.cpp"
    "filters/*.cpp"
    "io/*.cpp"
    "pointcloud/*.cpp"
    "registration/*.cpp"
    "sampleconsensus/*.cpp"
    "search/*.cpp"
    "segmentation/*.cpp"
    "std/*.cpp"
    "surface/*.cpp"
    "PointSizes.cpp"
)

# Collect header files
file(GLOB_RECURSE EXTERN_HEADERS
    "*.h"
    "*.hpp"
)

# Create shared library
add_library(PclSharp.Extern SHARED 
    ${EXTERN_SOURCES}
    ${EXTERN_HEADERS}
)

# Include directories
target_include_directories(PclSharp.Extern PRIVATE
    ${PCL_INCLUDE_DIRS}
    ${VTK_INCLUDE_DIRS}
    ${Boost_INCLUDE_DIRS}
    ${OPENNI2_INCLUDE_DIRS}
    ${FLANN_INCLUDE_DIRS}
    ${QHULL_INCLUDE_DIRS}
)

# Link libraries
target_link_libraries(PclSharp.Extern PRIVATE
    ${PCL_LIBRARIES}
    ${VTK_LIBRARIES}
    ${Boost_LIBRARIES}
    ${OPENNI2_LIBRARIES}
    ${FLANN_LIBRARIES}
    ${QHULL_LIBRARIES}
)

# Set output directories
set_target_properties(PclSharp.Extern PROPERTIES
    RUNTIME_OUTPUT_DIRECTORY "${CMAKE_BINARY_DIR}/bin"
    LIBRARY_OUTPUT_DIRECTORY "${CMAKE_BINARY_DIR}/bin"
    ARCHIVE_OUTPUT_DIRECTORY "${CMAKE_BINARY_DIR}/lib"
)

# Windows-specific settings
if(WIN32)
    target_link_libraries(PclSharp.Extern PRIVATE
        vfw32
        glu32
        opengl32
        comctl32
        wsock32
        ws2_32
        Psapi
    )
    
    # Add VTK module initialization for VTK 9
    vtk_module_autoinit(
        TARGETS PclSharp.Extern
        MODULES ${VTK_LIBRARIES}
    )
endif()