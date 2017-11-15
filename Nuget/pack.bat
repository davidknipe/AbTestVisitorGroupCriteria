@Echo Setting up folder structure
md Package\lib\net45\
md Package\tools\
md Package\content\lang\

@Echo Removing old files
del /Q Package\lib\net45\*.*

@Echo Copying new files
copy ..\AbTestVisitorGroupCriteria\bin\Release\AbTestVisitorGroupCriteria.dll Package\lib\net45 
copy ..\AbTestVisitorGroupCriteria\lang\AbTestVisitorGroupCriteria.xml Package\content\lang\AbTestVisitorGroupCriteria.xml

@Echo Packing files
"..\.nuget\nuget.exe" pack package\AbTestVisitorGroupCriteria.nuspec

@Echo Moving package
move /Y *.nupkg c:\project\nuget.local\