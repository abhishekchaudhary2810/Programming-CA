using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<string, string> fileTypes = new Dictionary<string, string>()
        {
            { ".mp4", "Video File (MPEG-4)" },
            { ".exe", "Windows Executable Program" },
            { ".mov", "Video File (Apple QuickTime)" },
            { ".mkv", "Video File (Matroska)" },
            { ".webm", "Web Media Video File" },
            { ".mp3", "Audio File (MPEG Layer 3)" },
            { ".wav", "Uncompressed Audio File" },
            { ".pdf", "Document File (Portable Document Format)" },
            { ".flac", "Lossless Audio File" },
            { ".pptx", "Microsoft PowerPoint Presentation" },
            { ".jpg", "Image File (JPEG)" },
            { ".jpeg", "Image File (JPEG)" },
            { ".gif", "Animated Image File" },
            { ".bmp", "Bitmap Image File" },
            { ".png", "Image File (Portable Network Graphics)" },
            { ".docx", "Microsoft Word Document" },
            { ".xlsx", "Microsoft Excel Spreadsheet" },
            { ".avi", "Video File (Audio Video Interleave)" },
            { ".txt", "Plain Text File" },
            { ".zip", "Compressed ZIP Archive" },
            
        };

        Console.WriteLine("--------FILE EXTENSION INFORMATION SYSTEM --------");

        while (true)
        {
            Console.Write("\nEnter a file extension (e.g. .mp4) or type 'exit' to quit: ");
            string ext = Console.ReadLine().ToLower();

            if (ext == "exit")
            {
                Console.WriteLine("Goodbye!");
                break;
            }

            if (fileTypes.ContainsKey(ext))
            {
                Console.WriteLine($"Extension {ext} → {fileTypes[ext]}");
            }
            else
            {
                Console.WriteLine($"Sorry, I don't know about '{ext}'. Try another one!");
            }
        }
    }
}

