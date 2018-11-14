using System;

namespace Test_R
{
    class Root
    {
        //Model root folder
        // get and set properties
        public string name { get; set; }
        public int dev { get; set; }
        public int mode { get; set; }
        public int nlink { get; set; }
        public int uid { get; set; }
        public int gid { get; set; }
        public int rdev { get; set; }
        public int blksize { get; set; }
        public int ino { get; set; }
        public int size { get; set; }
        public int blocks { get; set; }
        public float atimeMs { get; set; }
        public float mtimeMs { get; set; }
        public float ctimeMs { get; set; }
        public float birthtimeMs { get; set; }
        public DateTime atime { get; set; }
        public DateTime mtime { get; set; }
        public DateTime ctime { get; set; }
        public DateTime birthtime { get; set; }
        public Content content { get; set; }
        public string path { get; set; }
    }

    class Content {
        public Folder Folder1 { get; set; }
        public Folder Folder2 { get; set; }

    }
}
