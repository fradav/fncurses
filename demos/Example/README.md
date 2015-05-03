# Recursively copy the lib folder to the output directory

## Windows Post Build Event

    xcopy $(ProjectDir)..\..\lib $(TargetDir)lib /s /e /h /i /y
 
