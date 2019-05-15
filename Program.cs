using System;
using System.IO;
using System.Threading;
using System.Text;
using System.Collections.Generic;

class File {
    private byte[] log;
    private byte[] log_temp;

    static void Main(string[] args) {
        File f = new File();
        int[] data_index = new int[56] {
                0, 1, 2, 3, 7, 14, 15, 16, 19, 22, 24, 25, 26,
                28, 29, 30, 31, 34, 37, 39, 40, 43, 46, 47, 50,
                54, 60, 63, 65, 66, 67, 71, 75, 77, 81, 83, 84,
                87, 88, 91, 94, 97, 99, 101, 104, 105, 117, 118,
                120, 122, 124, 126, 127, 128, 133, 134,
        };

        int[] data_size = new int[56] {
                1, 1, 1, 4, 7, 1, 1, 3, 3, 2, 1, 1, 2, 1,
                1, 1, 3, 3, 2, 1, 3, 3, 1, 3, 4, 6, 3, 2,
                1, 1, 4, 4, 2, 4, 2, 1, 3, 1, 3, 3, 3, 2,
                2, 3, 1, 12, 1, 1, 2, 2, 2, 2, 1, 1, 5, 1
        };

        int data_length = (int)data_index.Length;
        string path = "/Users/bobby/Downloads/Work/034002LO300007.100.7A3";

        // read Log to byte[] log
        FileStream reader = new FileStream(path, FileMode.Open);
        f.log = new byte[(int)reader.Length]; //1277
        reader.Read(f.log, 0, (int)reader.Length);
        reader.Close();

        
        int sourceIndex = 0;

        while (true) {
            if (f.log[1] == 110 || f.log[1] == 111 || f.log[1] == 112 || f.log[1] == 113) {
                // for (int index = 0 ; index < data_length ; index++) {
                //     Console.WriteLine(log[data_index[index]]);
                // }
                Console.WriteLine(f.Byte_to_unixtime(3, 4));
                Console.WriteLine("-----------------------------------------------------------------------------");
            }
            
            sourceIndex = f.log[0] + 1;
            if (f.log.Length - sourceIndex == 0) break;
            f.log_temp = new byte[f.log.Length - sourceIndex];
            Array.Copy(f.log, sourceIndex, f.log_temp, 0, f.log.Length - sourceIndex);
            f.log = f.log_temp;
        }
    }

    private string Byte_to_unixtime(int index, int length) {
        log_temp = new byte[length];
        string datestring = "";
        for (int i = 0 ; i < log_temp.Length ; i++) {
            datestring += Convert.ToString(log_temp[i], 16).PadLeft(2, '0');
        }
        long unixtime = Convert.ToInt64(datestring, 16);
        DateTime date = new DateTime(1970, 1, 1, 0, 0, 0, 0);
        date = date.AddSeconds(unixtime);
        return date.ToString("yyyy/MM/dd HH:MM:ss");
    }
}