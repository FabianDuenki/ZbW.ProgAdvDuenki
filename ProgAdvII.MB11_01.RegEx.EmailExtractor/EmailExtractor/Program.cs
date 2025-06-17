using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace EmailExtractor {
    class Program {
        static void Main(string[] args) {

            var text = @"boleh di kirim ke email saya ekoprasetyo.crb@outlook.com tks...
boleh minta kirim ke db.maulana@gmail.com. 
dee.wien@yahoo.. .
deninainggolan@yahoo.co.id Senior Quantity Surveyor
Fajar.rohita@hotmail.com, terimakasih bu Cindy Hartanto
firmansyah1404@gmail.com saya mau dong bu cindy
fransiscajw@gmail.com 
Hi Cindy ...pls share the Salary guide to donny_tri_wardono@yahoo.co.id thank a";

            var mails = ExtractEmails(text);
            foreach (var mail in mails)
            {
                Console.WriteLine(mail);
            }
        }


        public static List<string> ExtractEmails(string text) {
            var list = new List<string>();
            string pattern = "(\\w+|\\w+\\.)+@(\\w+\\.)+\\w+";
            foreach(var match in Regex.Matches(text, pattern))
            {
                list.Add(match.ToString());
            }
            // TODO: extract Mailadresses from text and add it to list

            return list;
        }
    }
}
