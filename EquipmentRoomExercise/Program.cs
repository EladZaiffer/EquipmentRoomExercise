using System;

// <summary>
//Todo: צרו מחלקת חריגים המטפלת במקרים בהם אין מספיק מחשבים זמינים להשאלה.
//שם המחלקה צריך להיות EquipmentUnavailableException.



class EquipmentRoom
{
    private int availableComputers;

    public int AvailableComputers
    {
        get
        {
            return availableComputers;
        }
        set
        {
            // TODO: יש לבדוק שמספר המחשבים אינו שלילי.
            // אם כן, יש לזרוק חריגה מתאימה.
            if (value < 0)
            {
                throw new ArgumentException("Number of computers cannot be negative.");
            }
            availableComputers = value;
        }
    }

    public EquipmentRoom(int amount)
    {
        AvailableComputers = amount;
    }

    public void Borrow(int amount)
    {
       
            // TODO: יש לזרוק חריגה מתאימה כאשר אין מספיק מחשבים זמינים.
        if (amount > AvailableComputers)
        {
            int missingAmount = amount - AvailableComputers;
            throw new EquipmentUnavailableException("Not enough computers available.", amount, missingAmount);
        } 
        AvailableComputers -= amount;
        Console.WriteLine($"{amount} computers borrowed successfully.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // יצירת חדר מחשבים עם מספר מחשבים שלילי:
        // לאחר מימוש הבדיקה ב-set, יש לוודא שמצב כזה מטופל כראוי.
        // TODO: יש להוסיף try-catch מתאימים סביב הקריאות שעלולות לזרוק חריגה.
        // int negativeComputers = -5;
        // EquipmentRoom invalidRoom = new EquipmentRoom(negativeComputers)
        int initialComputers = 10;
        EquipmentRoom room = new EquipmentRoom(initialComputers);
        try
        {
            int negativeComputers = -5;
            EquipmentRoom invalidRoom = new EquipmentRoom(negativeComputers);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Error creating the room: " + ex.Message);
        }

        try
        {
            room.Borrow(4);
        }
        catch (EquipmentUnavailableException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Number of items requested: " + ex.RequestedAmount);
            Console.WriteLine("Missing amount: " + ex.MissingAmount);
        }

        Console.WriteLine("Continuing with the program...");

        try
        {
            room.Borrow(8);
        }
        catch (EquipmentUnavailableException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Number of items requested: " + ex.RequestedAmount);
            Console.WriteLine("Missing amount: " + ex.MissingAmount);
        }

        Console.WriteLine("Available computers: " + room.AvailableComputers);
    }

}

