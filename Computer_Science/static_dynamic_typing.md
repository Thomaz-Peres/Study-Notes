Languages which is statically typed, which means type errors are detected and reported at compile time before any code is run.

Languages which is dynamically typed and defer checking for type errors until runtime right before an operation is attempted.


Even most statically typed languages do some type checks at runtime. The type system checks most type rules statically, but inserts runtime checks in the generated code for other operations.


I always forget:

Compile:
    - Create the bytecode.
    - Check the syntax errors, types errors.
    - While running the scanner and parser, not running code, just compile.


Runtime:
    - When execute the code, usually in the interpreter.
