using System;
using System.IO;
using System.Threading;

namespace _1._4_CompletionCallback {
    //interface IFileReaderClient // Callback Interface
    //{
    //    void ReadCompleted(String filename, byte[] data);
    //    void ReadFailed(String filename, IOException ex);
    //}
    public delegate void ReadCompletedHandler(String filename, byte[] data);

    public delegate void ReadFailedHandler(String filename, IOException ex);

    class FileReader {
        public static void ReadAsync(String filename, ReadCompletedHandler readCompleted, ReadFailedHandler readFailed) {
            // FileReaderAsync-Objekt mit korrekten Parametern erzeugen
            FileReaderAsync my = new FileReaderAsync(filename, readCompleted, readFailed);

            // Worker-Thread starten (führt DoRead asynchron aus)
            new Thread(my.DoRead).Start();
        }

        /// <summary>
        /// Internal Helper Class
        /// </summary>
        private class FileReaderAsync {
            private string fileName;
            private ReadCompletedHandler readCompleted;
            private ReadFailedHandler readFailed;

            public FileReaderAsync(String fn, ReadCompletedHandler readCompleted, ReadFailedHandler readFailed) {
                fileName = fn;
                this.readCompleted = readCompleted;
                this.readFailed = readFailed;
            }

            public void DoRead() {
                byte[] buffer = new byte[1024]; // Nur als Beispiel
                try {
                    FileStream s = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                    BinaryReader r = new BinaryReader(s);
                    buffer = r.ReadBytes(buffer.Length);
                    readCompleted?.Invoke(fileName, buffer);
                } catch (IOException ex) {
                    readFailed?.Invoke(fileName, ex);
                }
            }
        }
    }
}