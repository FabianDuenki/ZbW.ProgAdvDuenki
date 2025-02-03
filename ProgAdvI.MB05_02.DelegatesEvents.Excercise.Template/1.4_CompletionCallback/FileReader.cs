using System;
using System.IO;
using System.Threading;

namespace _1._4_CompletionCallback {
    interface IFileReaderClient // Callback Interface
    {
        void ReadCompleted(String filename, byte[] data);
        void ReadFailed(String filename, IOException ex);
    }

    class FileReader {
        public static void ReadAsync(String filename, IFileReaderClient client) {
            // FileReaderAsync-Objekt mit korrekten Parametern erzeugen
            FileReaderAsync my = new FileReaderAsync(filename, client);

            // Worker-Thread starten (führt DoRead asynchron aus)
            new Thread(my.DoRead).Start();
        }

        /// <summary>
        /// Internal Helper Class
        /// </summary>
        private class FileReaderAsync {
            private string fileName;
            private IFileReaderClient fileReaderClient;

            public FileReaderAsync(String fn, IFileReaderClient c) {
                fileName = fn;
                fileReaderClient = c;
            }

            public void DoRead() {
                byte[] buffer = new byte[1024]; // Nur als Beispiel
                try {
                    FileStream s = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                    BinaryReader r = new BinaryReader(s);
                    buffer = r.ReadBytes(buffer.Length);
                    fileReaderClient?.ReadCompleted(fileName, buffer);
                } catch (IOException ex) {
                    fileReaderClient?.ReadFailed(fileName, ex);
                }
            }
        }
    }
}