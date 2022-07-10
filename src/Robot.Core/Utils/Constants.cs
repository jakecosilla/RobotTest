namespace Robot.Core.Utils
{
    /// <summary>
    /// Static string values.
    /// </summary>
    public static class Constants
    {
        public const string PLACE_COMMAND = "place";
        public const string MOVE_COMMAND = "move";
        public const string LEFT_COMMAND = "left";
        public const string RIGHT_COMMAND = "right";
        public const string REPORT_COMMAND = "report";
        public const string NORTH_DIRECTION = "north";
        public const string SOUTH_DIRECTION = "south";
        public const string EAST_DIRECTION = "east";
        public const string WEST_DIRECTION = "west";
        public const string REPORT_XAXIS_LABEL = "x-axis";
        public const string REPORT_YAXIS_LABEL = "y-axis";
        public const string REPORT_DIRECTION_LABEL = "Direction";
        public const int DIMENSION_CENTER_DIVISOR = 2; // to get the center in the axis
        public const int NEGATIVE_AXIS = -1; // to get the center in the axis
        public const int MOVE_VALUE = 1; // number of square going in the direction
        public const int DIRECTION_QUARTER_VALUE = 4;
        public const int DIRECTION_ROTATE = 1; // 90 degrees
        public const string MESSAGE_CANNOT_MOVE = "Cannot move further! The robot will fall.";
        public const string MESSAGE_NO_COMMAND_EXECUTED = "No command executed.";
        public const string MESSAGE_NOT_VALID_COMMAND = "is not a valid command.";
        public const string MESSAGE_PLACE_COMMAND_REQUIRED = "Place command required before running";
        public const string MESSAGE_INVALID_DIRECTION = "Invalid direction. Must be north, south, east and west only.";
        public const string MESSAGE_PLACE_REQUIRED_PARAMS = "X, Y and Direction are required in place command.";
        public const string MESSAGE_PLACE_INCOMPLETE_ARGUMENTS = "Incomplete place command arguments.";
        public const string MESSAGE_PLACE_INVALID_XAXIS = "Invalid x-axis value";
        public const string MESSAGE_PLACE_INVALID_YAXIS = "Invalid y-axis value";
    }
}