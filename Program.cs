// Prints an invalid message in case user is not pressing "a", "s", "r", "e";
void InvalidMessage()
{
    Console.WriteLine("Invalid choice.");
}

void TodoOptions()
{
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("[S]ee all TODOs");
    Console.WriteLine("[A]dd a TODO");
    Console.WriteLine("[R]emove a TODO");
    Console.WriteLine("[E]xit");
}

// Check if the description is unique;
bool VerifyIfDescriptionUnique(List<string> tasks, string taskDescription)
{
    if(tasks.Contains(taskDescription))
    {
        return false;
    }
    return true;
}

// We add a task that is not Null or Empty to a given list
void AddTaskToList(List<string> tasks)
{   
    string taskDescription = "";
    bool isDescriptionValid;

     do
        {
            Console.Write("Enter the TODO description: ");
            taskDescription = Console.ReadLine();

            if(String.IsNullOrEmpty(taskDescription))
            {
                   Console.WriteLine("The description cannot be empty.");
                   isDescriptionValid = false;
            }
            else if(!VerifyIfDescriptionUnique(tasks, taskDescription))
            {
                Console.WriteLine("The description must be unique.");
                isDescriptionValid = false;
            }
            else
            {
                isDescriptionValid = true;
            }   
        }while(!isDescriptionValid);

    tasks.Add(taskDescription);
    Console.WriteLine($"TODO successfully added: {taskDescription}\n");
}

void ShowExistingTasks(List<string> tasks) 
{
    if(tasks.Count == 0)
    {
        Console.WriteLine("The list of task is empty. Press 'a' to add new ones");
        return;
    }

    else {
        int i = 1;
        foreach(var task in tasks)
        {
            Console.WriteLine($"{i}. {task}");
            ++i;
        }
    }

}



void RemoveTask(List<string> tasks)
{

    if (tasks.Count == 0)
    {
        Console.WriteLine("There are no TODOs to remove.");
        return;
    }
    
    Console.WriteLine("Select the index of the TODO you want to remove.");
    ShowExistingTasks(tasks);

    string userIndex = Console.ReadLine();

    bool isIndexEmpty = String.IsNullOrEmpty(userIndex);
    bool isIndexValid = false;

    bool isInt = int.TryParse(userIndex, out int index);
    if(isInt && index <= tasks.Count && index >= 1)
    {
        isIndexValid = true;
    }


    if(isIndexEmpty || !isIndexValid)
    {
        do
        {
            if(isIndexEmpty) Console.WriteLine("Selected index cannot be empty.");
            else if(!isIndexValid) Console.WriteLine("The given index is not valid.");

            Console.WriteLine("Select the index of the TODO you want to remove.");
            ShowExistingTasks(tasks);

            userIndex = Console.ReadLine();

            isIndexEmpty = String.IsNullOrEmpty(userIndex);
            isIndexValid = false;

            isInt = int.TryParse(userIndex, out index);
            if(isInt && index <= tasks.Count && index >= 1)
            {
                isIndexValid = true;
            }
            
        
        }while(isIndexEmpty || !isIndexValid);
    }

    tasks.RemoveAt(index - 1);
}

TodoOptions();


// Declaring the task list here

var tasks = new List<string>();


var userChoice = Console.ReadLine();

while(userChoice != "e")
{
    if(userChoice == "s")
    {
       ShowExistingTasks(tasks);
    } 

    else if(userChoice == "a")
    {
        AddTaskToList(tasks);
    }       

    else if(userChoice == "r")
    {
        RemoveTask(tasks);
    }

    else
    {
        InvalidMessage();
    }

    TodoOptions();
    userChoice = Console.ReadLine();

}

Console.WriteLine("Well Done! See you another time. Relax now, you deserve it!");


