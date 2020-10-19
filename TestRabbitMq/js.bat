
@echo off
for %%i in (*.proto) do (
    protoc --js_out=./ %%i
    rem 从这里往下都是注释，可忽略
    echo From %%i To %%~ni.js Successfully!  
)
