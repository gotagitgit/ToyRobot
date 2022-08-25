namespace ToyRobot.ConsoleApp
{
    internal class FileService
    {
        public static List<string> GetCommands(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException(filePath);

            var commands = new List<string>();

            using (var stream = new StreamReader(filePath))
            {                
                string line;

                while ((line = stream.ReadLine()) != null)
                {
                    if (!string.IsNullOrEmpty(line))
                        commands.Add(line.Trim());                    
                }
                stream.Close();                
            }

            return commands;
        }        
    }
}
