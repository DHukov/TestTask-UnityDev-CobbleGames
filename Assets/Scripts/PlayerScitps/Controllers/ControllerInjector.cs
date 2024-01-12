public class ControllerInjector
{
    IMoveController moveController;
    public IMoveController Init(ControllType controllType)
    {
        switch (controllType)
        {
            case ControllType.MouseNavMesh:
                moveController = new NavMeshPlayerMovementController();
                return moveController;
            case ControllType.Keyborad:
                moveController = new KeyboradPlayerMovementController();
                return moveController;
            case ControllType.AIFollower:
                moveController = new AIFollowerController();
                return moveController;
        }
        return moveController;
    }
}
