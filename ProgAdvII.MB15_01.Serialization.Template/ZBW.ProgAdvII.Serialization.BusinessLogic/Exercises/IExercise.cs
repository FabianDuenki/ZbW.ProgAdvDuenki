namespace ZBW.ProgAdvII.Serialization.BusinessLogic.Exercises {
    public interface IExercise {
        int GetNumber();

        string GetDescription();
        ExerciseResult Execute();
    }
}