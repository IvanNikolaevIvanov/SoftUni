using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public interface IReptile
{
    public ReptileEgg LayEgg();
}

public class FireDragon : IReptile
{


    public ReptileEgg LayEgg()
    {

        var newEgg = new ReptileEgg("FireDragon");

        return newEgg;
    }


}

public class ReptileEgg
{
    private bool isHatched = false;
    private string reptileType = "";

    public ReptileEgg(string reptileType)
    {
        this.reptileType = reptileType;
    }

    public IReptile Hatch()
    {
        if (isHatched == false)
        {
            if (reptileType == "FireDragon")
            {
                IReptile newReptile = new FireDragon();
                isHatched = true;
                return newReptile;
            }
        }
        else
        {
            throw new ArgumentException("Egg has already been hatched!");
            
        }

        return null;

    }
}
