public static class Constants
{
//	public static readonly string PlayerTag = "Player";
//	public static readonly string AnimationStarted = "started";
//	public static readonly string AnimationJump = "jump";
//	public static readonly string WidePathBorderTag = "WidePathBorder";
//	public static readonly string StatusTapToStart = "Tap to start";
	public static readonly int mapSectionDepth = 4;
	public static readonly int totalLengthOfLevel = 400;

	public static readonly float forwardMovementSpeed = 3f;
	public static readonly float strafeMovementSpeed = .1f; // must divide evenly into 10!

	public static readonly float fireballSpeed = 6f;

	public static readonly int playerLifeCount = 3;

	public static readonly int chanceOfEnemyPlacement = 50; // % chance to place an enemy (0-100%)

	// Tower instantiation offset
	public static readonly float towerInstatiationYOffset = 0.5002f;
	public static readonly float towerInstatiationZOffset = 1f;

}

