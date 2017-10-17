using System;
using static System.Console;

namespace Iko {
    static class Console {
        public static double GetDouble(string text, Func<double, bool> validate, string falseText) {
            Write(text);
            double res;
            while (true) {
                if (double.TryParse(ReadLine(), out res) && validate(res)) {
                    return res;
                } else {
                    WriteLine(falseText);
                    Write(text);
                }
            }
        }

        public static double GetDouble(string text, string falseText) {
            return GetDouble(text, _ => { return true; }, falseText);
        }

        public static float GetFloat(string text, Func<float, bool> validate, string falseText) {
            Write(text);
            float res;
            while (true) {
                if (float.TryParse(ReadLine(), out res) && validate(res)) {
                    return res;
                } else {
                    WriteLine(falseText);
                    Write(text);
                }
            }
        }

        public static float GetFloat(string text, string falseText) {
            return GetFloat(text, _ => { return true; }, falseText);
        }

        public static int GetInt(string text, Func<int, bool> validate, string falseText) {
            Write(text);
            int res;
            while (true) {
                if (int.TryParse(ReadLine(), out res) && validate(res)) {
                    return res;
                } else {
                    WriteLine(falseText);
                    Write(text);
                }
            }
        }

        public static int GetInt(string text, string falseText) {
            return GetInt(text, _ => { return true; }, falseText);
        }

        public static void Repeat(Action f) {
            do {
                f();
                Write("Press Enter to repeat program. Press any other key to quit.");
            } while (ReadKey().Key == ConsoleKey.Enter);
        }
    }
}