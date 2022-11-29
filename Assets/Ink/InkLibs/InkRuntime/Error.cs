<<<<<<< HEAD
<<<<<<< HEAD
﻿namespace Ink
{
    /// <summary>
    /// Callback for errors throughout both the ink runtime and compiler.
    /// </summary>
    public delegate void ErrorHandler(string message, ErrorType type);

    /// <summary>
    /// Author errors will only ever come from the compiler so don't need to be handled
    /// by your Story error handler. The "Error" ErrorType is by far the most common
    /// for a runtime story error (rather than compiler error), though the Warning type
    /// is also possible. 
    /// </summary>
    public enum ErrorType
    {
        /// Generated by a "TODO" note in the ink source
        Author,
        /// You should probably fix this, but it's not critical
        Warning,
        /// Critical error that can't be recovered from
        Error
    }
}

=======
=======
>>>>>>> main
﻿namespace Ink
{
    /// <summary>
    /// Callback for errors throughout both the ink runtime and compiler.
    /// </summary>
    public delegate void ErrorHandler(string message, ErrorType type);

    /// <summary>
    /// Author errors will only ever come from the compiler so don't need to be handled
    /// by your Story error handler. The "Error" ErrorType is by far the most common
    /// for a runtime story error (rather than compiler error), though the Warning type
    /// is also possible. 
    /// </summary>
    public enum ErrorType
    {
        /// Generated by a "TODO" note in the ink source
        Author,
        /// You should probably fix this, but it's not critical
        Warning,
        /// Critical error that can't be recovered from
        Error
    }
}

<<<<<<< HEAD
>>>>>>> Programming
=======
>>>>>>> main
