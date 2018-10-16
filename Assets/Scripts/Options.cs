using System;

/// <summary>
/// This is our options singleton. The instance must be used to set or get any options.
/// </summary>
public class Options {
    // This is the instance that anyone can access
    public static Options Instance = new Options();

    // Create the default options
    public static readonly OptionsBuilder DEFAULTS = new OptionsBuilder() {
        mouseSensitivity = 10,
    };


    // This is the lock we will use whenever we try to change something in the options
    private readonly object myLock = new object();

    //////// Keep all of our options private (Build another level for synchronization)
    private uint _mouseSensitivity;

    /////// Make getters for all of our options
    public uint mouseSensitivity {
        get { lock(myLock) { return _mouseSensitivity; } }
    }

    // Make our constructor private so that nothing else can create other Options
    private Options() {}
    static Options() {
        // Always merge with the defaults on start-up
        Instance.merge(DEFAULTS);
        // We can load in any options read from a file later, and overwrite the defaults
    }

    /// <summary>
    /// Merges the options from the options builder. Checks all of the options to make sure that they're good. Just skips bad options.
    /// </summary>
    public void merge(OptionsBuilder builder) {
        // Lock everything, so that no-one else can read it while we're updating
        lock(myLock) {
            /// Sets the mouse sensitivity. The range is 1 - 100, so nothing happens if the given value is greater than 100 or 0
            if (builder.mouseSensitivity.HasValue &&
                (1 <= builder.mouseSensitivity.Value && builder.mouseSensitivity.Value <= 100)) {
                _mouseSensitivity = builder.mouseSensitivity.Value;
            }
        }
    }

    /// <summary>
    /// This is a builder for the options, so that we can stage our options before pushing them into our global options.
    /// All of our options in the builder need to be nullable, so we can see which ones were set
    /// </summary>
    public class OptionsBuilder {
        public uint? mouseSensitivity;
    }
}
