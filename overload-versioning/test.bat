csc /t:library /out:library.dll library.v1.cs 
csc /r:library.dll program.cs
program
csc /t:library /out:library.dll library.v2.cs 
program
csc /r:library.dll program.cs
program
