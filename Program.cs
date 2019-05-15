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
                    string[] data = new string[56];
                    data[0] = f.log[0].ToString();
                    data[1] = f.log[1].ToString();
                    data[2] = f.log[2].ToString();
                    data[3] = f.byte_convert_unix_date_time(3, 4, true);
                    data[4] = f.byte_to_hex_string_to_hex(7, 7, true).ToString();
                    data[5] = f.log[14].ToString(); 
                    data[6] = f.log[15].ToString();
                    data[7] = f.byte_to_hex_string_to_hex(16, 3, true).ToString();
                    data[8] = f.byte_to_hex_string_to_hex(19, 3, true).ToString();
                    data[9] = f.byte_to_hex_string_to_hex(22, 2, true).ToString();
                    data[10] = f.log[24].ToString();
                    data[11] = "0x" + f.byte_to_hex_string_to_hex(25, 1, true).ToString();
                    data[12] = "0x" + f.byte_to_hex_string_to_hex(26, 2, true).ToString();
                    data[13] = f.log[28].ToString();
                    data[14] = f.log[29].ToString();
                    data[15] = f.log[30].ToString();
                    data[16] = f.byte_to_hex_string_to_hex(31, 3, true).ToString();
                    data[17] = f.byte_to_hex_string_to_hex(34, 3, true).ToString();
                    data[18] = f.byte_to_hex_string_to_hex(37, 2, true).ToString();
                    data[19] = f.log[39].ToString();
                    data[20] = f.byte_to_hex_string_to_hex(40, 3, true).ToString();
                    data[21] = f.byte_to_hex_string_to_hex(43, 3, true).ToString();
                    data[22] = f.log[46].ToString();
                    data[23] = f.byte_to_hex_string_to_hex(47, 3, true).ToString();
                    data[24] = f.byte_convert_unix_date_time(50, 4, true).ToString();
                    data[25] = "0x" + f.byte_to_hex_string_to_hex(54, 6, true).ToString();
                    data[26] = f.byte_to_hex_string_to_hex(60, 3, true).ToString();
                    data[27] = f.byte_to_hex_string_to_hex(63, 2, true).ToString();
                    data[28] = f.log[65].ToString();
                    data[29] = f.log[66].ToString();
                    data[30] = f.byte_to_hex_string_to_hex(67, 4, true).ToString();
                    data[31] = f.byte_to_hex_string_to_hex(71, 4, true).ToString();
                    data[32] = f.byte_to_hex_string_to_hex(75, 2, true).ToString();
                    data[33] = f.byte_convert_unix_date_time(77, 4, true).ToString();
                    data[34] = f.byte_to_hex_string_to_hex(81, 2, true).ToString();
                    data[35] = f.log[83].ToString();
                    data[36] = f.byte_to_hex_string_to_hex(84, 3, true).ToString();
                    data[37] = f.log[87].ToString();
                    data[38] = f.byte_to_hex_string_to_hex(88, 3, true).ToString();
                    data[39] = f.byte_to_hex_string_to_hex(91, 3, true).ToString();
                    data[40] = f.byte_to_hex_string_to_hex(94, 3, true).ToString();
                    data[41] = f.byte_to_hex_string_to_hex(97, 2, true).ToString();
                    data[42] = f.byte_to_hex_string_to_hex(99, 2, true).ToString();
                    data[43] = f.byte_to_hex_string_to_hex(101, 3, true).ToString();
                    data[44] = f.rfu_format(104, 1, false);
                    data[45] = f.rfu_format(105, 12).ToString() ;
                    data[46] = f.log[117].ToString();
                    data[47] = f.log[118].ToString();
                    data[48] = f.byte_to_hex_string_to_hex(119, 2).ToString();
                    data[49] = f.byte_to_hex_string_to_hex(121, 2, true).ToString();
                    data[50] = f.byte_to_hex_string_to_hex(123, 2, false).ToString();
                    data[51] = f.byte_to_hex_string_to_hex(125, 2, false).ToString();
                    data[52] = f.log[127].ToString();
                    data[53] = f.byte_to_hex_string_to_hex(128, 1, true).ToString();
                    data[54] = f.rfu_format(129, 5).ToString();
                    data[55] = f.log[134].ToString();
            }
            
            sourceIndex = f.log[0] + 1;
            if (f.log.Length - sourceIndex == 0) break;
            f.log_temp = new byte[f.log.Length - sourceIndex];
            Array.Copy(f.log, sourceIndex, f.log_temp, 0, f.log.Length - sourceIndex);
            f.log = f.log_temp;
        }
    }

    private String byte_to_unicode_merge(int index, int num)
        {
            byte[] logs_array_temp = new byte[num];
            Array.Copy(log, index, logs_array_temp, 0, num);

            String string_merge = "";

            for (int temp = 0; temp < num - 1; temp++)
            {
                string_merge += (char)logs_array_temp[temp];
            }

            return string_merge;
        }

    private String byte_convert_unix_date_time(int index, int num, bool LSB = false)
    {

        log_temp = new byte[num];
        Array.Copy(log, index, log_temp, 0, num);

        if (LSB) { log_temp = change_hlbyte(log_temp); }
        String rltStr = "";
        for (int i = 0; i < log_temp.Length; i++)
        {
            rltStr += Convert.ToString(log_temp[i], 16).PadLeft(2, '0');
        }
        long unixTime = Convert.ToInt64(rltStr, 16);

        DateTime origin1 = new DateTime(1970, 1, 1, 0, 0, 0, 0);
        origin1 = origin1.AddSeconds(unixTime);

        return origin1.ToString("yyyy/MM/dd HH:mm:ss");
    }

    private byte[] change_hlbyte(byte[] byte_temp)
    {
        byte[] byte_convert = new byte[byte_temp.Length];

        int j = 0;
        for (int i = byte_temp.Length - 1; i >= 0; i--)
        {
            byte_convert[j] = byte_temp[i];
            j++;
        }

        return byte_convert;
    }

    private String byte_to_hex_string(int index, int num, bool LSB = false)
    {
        log_temp = new byte[num];
        Array.Copy(log, index, log_temp, 0, num);

        if (LSB) { log_temp = change_hlbyte(log_temp); }

        String hex_string = string.Empty;
        if (log_temp != null)
        {
            StringBuilder strB = new StringBuilder();

            for (int i = 0; i < log_temp.Length; i++)
            {
                strB.Append(log_temp[i].ToString("X2"));
            }
            hex_string = strB.ToString();
        }
        return hex_string;
    }

    private uint byte_to_hex_string_to_hex(int index, int num, bool LSB = false) //e.g. AAAA to 0xAAAA
    {
        log_temp = new byte[num];
        Array.Copy(log, index, log_temp, 0, num);

        if (LSB) { log_temp = change_hlbyte(log_temp); }

        String hex_string = string.Empty;
        if (log_temp != null)
        {
            StringBuilder strB = new StringBuilder();

            for (int i = 0; i < log_temp.Length; i++)
            {
                strB.Append(log_temp[i].ToString("X2"));
            }
            hex_string = strB.ToString();
        }

        return Convert.ToUInt32(hex_string, 16);
    }

    //´OØdƒÊ¶Ï™∫ÆÊ¶°
    private String rfu_format(int index, int num, bool LSB = false) //e.g. 0 0 0 0 31 35
    {
        log_temp = new byte[num];
        Array.Copy(log, index, log_temp, 0, num);

        if (LSB) { log_temp = change_hlbyte(log_temp); }

        String string_format = "";
        if (log_temp != null)
        {
            for (int i = 0; i < log_temp.Length; i++)
            {
                string_format += log_temp[i] + " ";
            }
        }

        return string_format;
    }

    //convert
    private String sub_type(int type)
    {
        switch (type)
        {
            case 0:
                return "¥∂≥q";
            case 1:
                return "∑q¶—";
            case 2:
                return "∑q¶—";
            case 3:
                return "∑R§ﬂ";
            case 4:
                return "≥≠¶Ò";
            case 5:
                return "æ«•Õ";
            case 6:
                return "æ«•Õ";
            case 7:
                return "ƒµπÓ";
            case 8:
                return "´ƒµ£¿u´›";
            default:
                return type.ToString();
        }
    }

    // private String data_record(int type)
    // {

    //     switch (type)
    //     {
    //         //case 1:
    //         //    return "¨q¶∏";
    //         case 110:
    //             return "";
    //         case 111:
    //             return "∏Ù¨G";
    //         case 112:
    //             return "ØS≥\";
    //         case 114:
    //             return "ØS∫ÿ≤º";
    //         default:
    //             return type.ToString();

    //     }
    // }

    private String entry_exit_flag(int type)
    {
        switch (type)
        {
            case 21:
                return "§W®Æ";
            case 20:
                return "§U®Æ";
            default:
                return type.ToString();
        }
    }

    private String owner_area_code(int type)
    {
        switch (type)
        {
            case 1:
                return "•x•_•´";
            case 2:
                return "∑s•_•´";
            case 3:
                return "∞Ú∂©•´";
            case 4:
                return "ÆÁ∂Èø§";
            case 5:
                return "©yƒıø§";
            case 6:
                return "≥s¶øø§";
            case 7:
                return "™˜™˘ø§";
            case 8:
                return "∑s¶À•´";
            case 9:
                return "∑s¶Àø§";
            case 10:
                return "ªO§§•´";
            case 12:
                return "∞™∂Ø•´";
            case 14:
                return "•x•_•´∑R§ﬂ2";
            case 15:
                return "∑s•_•´∑R§ﬂ2";
            case 16:
                return "π≈∏q•´";
            case 17:
                return "π≈∏qø§";
            case 18:
                return "∂≥™Lø§";
            case 19:
                return "ªO´n•´";
            case 21:
                return "≠]Æﬂø§";
            case 22:
                return "´nßÎø§";
            case 23:
                return "ºÍ¥Úø§";
            case 24:
                return "´Ã™Fø§";
            case 25:
                return "ªO™Fø§";
            case 26:
                return "™·Ω¨ø§";
            case 29:
                return "π¸§∆ø§";
            default:
                return type.ToString();
        }
    }

    private String transaction_amount(int type)
        {
            switch (type)
            {
                case 0:
                    return "§£¶©¥⁄";
                default:
                    return "¶©¥⁄";
            }

        }
}