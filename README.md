# Robot
Robot Command Controller

# Prerequisites
1. .Net 6.0 must be installed in your machine
2. Visual Studio 2022 is highly recommended to run this application

# Setup
1. Open the solution inside src
2. Set **Robot.App** as Startup Project
3. Build **Robot.App** or Run **Update-Package** in the package manager console
4. Run the application (Press F5)

# Commands
1. **PLACE X,Y,DIRECTION** - X and Y are integers that indicate a location on the tabletop.
DIRECTION is a string indicating which direction the robot should face. It it one of the four cardinal directions: NORTH, EAST, SOUTH or WEST.
2. **MOVE** - Instructs the robot to move 1 square in the direction it is facing.
3. **LEFT** - Instructs the robot to rotate 90° anticlockwise/counterclockwise.
4. **RIGHT** - Instructs the robot to rotate 90° clockwise.
5. **REPORT** - Outputs the robot's current location on the tabletop and the direction it is facing.

# Example Command
1. place 1 1 north
2. move
3. report

![image](https://user-images.githubusercontent.com/43627484/178165155-25261e1e-da00-4ae5-b197-2ae075f4645f.png)


# Technologies
1. .Net 6.0
2. XUnit
3. Fluent Assertions
4. Auto Fixtures
