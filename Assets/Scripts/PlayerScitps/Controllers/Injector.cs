public class Injector
{
    IMoveController moveController;
    public IMoveController Init(ControllType controllType)
    {
        switch (controllType)
        {
            case ControllType.MouseAStar:
                moveController = new AStarMouseController();
                return moveController;
            case ControllType.Keyborad:
                moveController = new KeyboradController();
                return moveController;
        }
        return moveController;
    }
}
