using System;

namespace daydream.Utils.Exceptions;

public class MalformedSceneTreeException : Exception {
    public MalformedSceneTreeException() { }
    public MalformedSceneTreeException(string message) : base("The scene tree is malformed: " + message) { }
    public MalformedSceneTreeException(string message, Exception inner) : base(message, inner) { }
}