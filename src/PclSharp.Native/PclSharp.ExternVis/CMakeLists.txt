# Collect source files
file(GLOB EXTERNVIS_SOURCES
    "*.cpp"
)

# Collect header files
file(GLOB EXTERNVIS_HEADERS
    "*.h"
)

# Create shared library
add_library(PclSharp.ExternVis SHARED 
    ${EXTERNVIS_SOURCES}
    ${EXTERNVIS_HEADERS}
)

# Include directories
target_include_directories(PclSharp.ExternVis PRIVATE
    ${PCL_INCLUDE_DIRS}
    ${VTK_INCLUDE_DIRS}
    ${Boost_INCLUDE_DIRS}
)

# Link libraries
target_link_libraries(PclSharp.ExternVis PRIVATE
    PclSharp.Extern
    ${PCL_VISUALIZATION_LIBRARIES}
    ${VTK_LIBRARIES}
    ${Boost_LIBRARIES}
)

# Set output directories
set_target_properties(PclSharp.ExternVis PROPERTIES
    RUNTIME_OUTPUT_DIRECTORY "${CMAKE_BINARY_DIR}/bin"
    LIBRARY_OUTPUT_DIRECTORY "${CMAKE_BINARY_DIR}/bin"
    ARCHIVE_OUTPUT_DIRECTORY "${CMAKE_BINARY_DIR}/lib"
)

# Windows-specific settings
if(WIN32)
    target_link_libraries(PclSharp.ExternVis PRIVATE
        opengl32
        glu32
    )
    
    # Add VTK module initialization for VTK 9
    vtk_module_autoinit(
        TARGETS PclSharp.ExternVis
        MODULES ${VTK_LIBRARIES}
    )
endif()