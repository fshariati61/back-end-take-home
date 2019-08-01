using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights.BLL
{
    public class Graph
    {
        // adjacency list 
        private Dictionary<string, List<string>> keyValueListDict;
        private List<string> valueList; 

        public Graph()
        {
            // initialise adjacency list  
            InitAdjList();
        }

        private void InitAdjList()
        {
            keyValueListDict = new Dictionary<string, List<string>>();
            valueList = new List<string>();
        }

        // Adds edge from origin to the destination  
        public void AddEdge(string origin, string destination)
        {
            if (keyValueListDict.ContainsKey(origin))
            {
                List<string> list_temp = new List<string>();
                list_temp = keyValueListDict[origin];


                if (list_temp.Contains(destination))
                {
                   // Console.WriteLine("key = {0} , list contains = {1} ", origin, destination);
                }
                else
                {
                    list_temp.Add(destination);
                }
            }
            else
            {
                keyValueListDict.Add(origin, new List<string> { destination });
            }

        }


        // Prints all paths from  'origin' to 'destination'  
         public string PrintAllPaths(string origin, string destination)
        {
            string resultPath = string.Empty;

            Dictionary<string, bool> Visited = new Dictionary<string, bool>();
            foreach (var kvp in keyValueListDict)
            {
                Visited[kvp.Key] = false;
            }

            List<string> pathList = new List<string>();

            // add source to path[]  
            pathList.Add(origin);

            // Call recursive utility  
            resultPath = PrintAllPathsUtil(origin, destination, Visited, pathList);
            return (resultPath);
        }

        // A recursive function to print all paths from source to the destination.  
        private string PrintAllPathsUtil(string source, string destination, Dictionary<string, bool> isVisited, List<string> localPathList)
        {

            // Mark the current node 
            string result = string.Empty;
            isVisited[source] = true;

            if (source.Equals(destination))
            {
                result = string.Join("->", localPathList);

                // if match found then no need to traverse more till depth
                isVisited[source] = false;

                return result;
            }

            // Recur for all the vertices adjacent to current vertex  
            foreach (string indx in keyValueListDict[source])
            {
                if (!isVisited[indx])
                {
                    // store current node in path[]  
                    localPathList.Add(indx);

                    result = PrintAllPathsUtil(indx, destination, isVisited, localPathList);

                    localPathList.Remove(indx);
                }
            }

            // Mark the current node  
            isVisited[source] = false;
            return result;
        }
    }
}

