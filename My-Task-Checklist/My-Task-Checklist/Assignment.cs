using System;

namespace MyTaskCheckList
{
    /// <summary>
    /// Simple object that represents an assignment.  Using it to keep track of the assignment properties including when it is dirty.
    /// </summary>
    public class Assignment
    {
        private string name;
        private Guid id;
        private bool done;
        private bool dirty;


        public Assignment(string taskName, Guid taskID, bool taskDone)
        {
            name = taskName;
            id = taskID;
            done = taskDone;
            dirty = false;
        }

        public override string ToString()
        {
            return name;
        }

        public bool Done
        {
            get
            {
                return done;
            }
            set
            {
                done = value;
                dirty = true;
            }

        }

        public Guid ID
        {
            get
            {
                return id;
            }

        }


        public bool Dirty
        {
            set {
                dirty = value;
            }

            get
            {
                return dirty;
            }
        }
    }
}
