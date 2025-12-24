
namespace ArithmeticCoding.H264
{
	public partial class H264CabacReader
	{
		private static readonly LevelListIndex[] LevelListIndicesTable = new LevelListIndex[]
		{
			// Index: 0
			new LevelListIndex() { SignificantCoeffFlagFrame = 0, SignificantCoeffFlagField = 0, LastSignificantCoeffFlag = 0 },
			// Index: 1
			new LevelListIndex() { SignificantCoeffFlagFrame = 1, SignificantCoeffFlagField = 1, LastSignificantCoeffFlag = 1 },
			// Index: 2
			new LevelListIndex() { SignificantCoeffFlagFrame = 2, SignificantCoeffFlagField = 1, LastSignificantCoeffFlag = 1 },
			// Index: 3
			new LevelListIndex() { SignificantCoeffFlagFrame = 3, SignificantCoeffFlagField = 2, LastSignificantCoeffFlag = 1 },
			// Index: 4
			new LevelListIndex() { SignificantCoeffFlagFrame = 4, SignificantCoeffFlagField = 2, LastSignificantCoeffFlag = 1 },
			// Index: 5
			new LevelListIndex() { SignificantCoeffFlagFrame = 5, SignificantCoeffFlagField = 3, LastSignificantCoeffFlag = 1 },
			// Index: 6
			new LevelListIndex() { SignificantCoeffFlagFrame = 5, SignificantCoeffFlagField = 3, LastSignificantCoeffFlag = 1 },
			// Index: 7
			new LevelListIndex() { SignificantCoeffFlagFrame = 4, SignificantCoeffFlagField = 4, LastSignificantCoeffFlag = 1 },
			// Index: 8
			new LevelListIndex() { SignificantCoeffFlagFrame = 4, SignificantCoeffFlagField = 5, LastSignificantCoeffFlag = 1 },
			// Index: 9
			new LevelListIndex() { SignificantCoeffFlagFrame = 3, SignificantCoeffFlagField = 6, LastSignificantCoeffFlag = 1 },
			// Index: 10
			new LevelListIndex() { SignificantCoeffFlagFrame = 3, SignificantCoeffFlagField = 7, LastSignificantCoeffFlag = 1 },
			// Index: 11
			new LevelListIndex() { SignificantCoeffFlagFrame = 4, SignificantCoeffFlagField = 7, LastSignificantCoeffFlag = 1 },
			// Index: 12
			new LevelListIndex() { SignificantCoeffFlagFrame = 4, SignificantCoeffFlagField = 7, LastSignificantCoeffFlag = 1 },
			// Index: 13
			new LevelListIndex() { SignificantCoeffFlagFrame = 4, SignificantCoeffFlagField = 8, LastSignificantCoeffFlag = 1 },
			// Index: 14
			new LevelListIndex() { SignificantCoeffFlagFrame = 5, SignificantCoeffFlagField = 4, LastSignificantCoeffFlag = 1 },
			// Index: 15
			new LevelListIndex() { SignificantCoeffFlagFrame = 5, SignificantCoeffFlagField = 5, LastSignificantCoeffFlag = 1 },
			// Index: 16
			new LevelListIndex() { SignificantCoeffFlagFrame = 4, SignificantCoeffFlagField = 6, LastSignificantCoeffFlag = 2 },
			// Index: 17
			new LevelListIndex() { SignificantCoeffFlagFrame = 4, SignificantCoeffFlagField = 9, LastSignificantCoeffFlag = 2 },
			// Index: 18
			new LevelListIndex() { SignificantCoeffFlagFrame = 4, SignificantCoeffFlagField = 10, LastSignificantCoeffFlag = 2 },
			// Index: 19
			new LevelListIndex() { SignificantCoeffFlagFrame = 4, SignificantCoeffFlagField = 10, LastSignificantCoeffFlag = 2 },
			// Index: 20
			new LevelListIndex() { SignificantCoeffFlagFrame = 3, SignificantCoeffFlagField = 8, LastSignificantCoeffFlag = 2 },
			// Index: 21
			new LevelListIndex() { SignificantCoeffFlagFrame = 3, SignificantCoeffFlagField = 11, LastSignificantCoeffFlag = 2 },
			// Index: 22
			new LevelListIndex() { SignificantCoeffFlagFrame = 6, SignificantCoeffFlagField = 12, LastSignificantCoeffFlag = 2 },
			// Index: 23
			new LevelListIndex() { SignificantCoeffFlagFrame = 7, SignificantCoeffFlagField = 11, LastSignificantCoeffFlag = 2 },
			// Index: 24
			new LevelListIndex() { SignificantCoeffFlagFrame = 7, SignificantCoeffFlagField = 9, LastSignificantCoeffFlag = 2 },
			// Index: 25
			new LevelListIndex() { SignificantCoeffFlagFrame = 7, SignificantCoeffFlagField = 9, LastSignificantCoeffFlag = 2 },
			// Index: 26
			new LevelListIndex() { SignificantCoeffFlagFrame = 8, SignificantCoeffFlagField = 10, LastSignificantCoeffFlag = 2 },
			// Index: 27
			new LevelListIndex() { SignificantCoeffFlagFrame = 9, SignificantCoeffFlagField = 10, LastSignificantCoeffFlag = 2 },
			// Index: 28
			new LevelListIndex() { SignificantCoeffFlagFrame = 10, SignificantCoeffFlagField = 8, LastSignificantCoeffFlag = 2 },
			// Index: 29
			new LevelListIndex() { SignificantCoeffFlagFrame = 9, SignificantCoeffFlagField = 11, LastSignificantCoeffFlag = 2 },
			// Index: 30
			new LevelListIndex() { SignificantCoeffFlagFrame = 8, SignificantCoeffFlagField = 12, LastSignificantCoeffFlag = 2 },
			// Index: 31
			new LevelListIndex() { SignificantCoeffFlagFrame = 7, SignificantCoeffFlagField = 11, LastSignificantCoeffFlag = 12 },
			// Index: 32
			new LevelListIndex() { SignificantCoeffFlagFrame = 7, SignificantCoeffFlagField = 9, LastSignificantCoeffFlag = 3 },
			// Index: 33
			new LevelListIndex() { SignificantCoeffFlagFrame = 6, SignificantCoeffFlagField = 9, LastSignificantCoeffFlag = 3 },
			// Index: 34
			new LevelListIndex() { SignificantCoeffFlagFrame = 11, SignificantCoeffFlagField = 10, LastSignificantCoeffFlag = 3 },
			// Index: 35
			new LevelListIndex() { SignificantCoeffFlagFrame = 12, SignificantCoeffFlagField = 10, LastSignificantCoeffFlag = 3 },
			// Index: 36
			new LevelListIndex() { SignificantCoeffFlagFrame = 13, SignificantCoeffFlagField = 8, LastSignificantCoeffFlag = 3 },
			// Index: 37
			new LevelListIndex() { SignificantCoeffFlagFrame = 11, SignificantCoeffFlagField = 11, LastSignificantCoeffFlag = 3 },
			// Index: 38
			new LevelListIndex() { SignificantCoeffFlagFrame = 6, SignificantCoeffFlagField = 12, LastSignificantCoeffFlag = 3 },
			// Index: 39
			new LevelListIndex() { SignificantCoeffFlagFrame = 7, SignificantCoeffFlagField = 11, LastSignificantCoeffFlag = 3 },
			// Index: 40
			new LevelListIndex() { SignificantCoeffFlagFrame = 8, SignificantCoeffFlagField = 9, LastSignificantCoeffFlag = 4 },
			// Index: 41
			new LevelListIndex() { SignificantCoeffFlagFrame = 9, SignificantCoeffFlagField = 9, LastSignificantCoeffFlag = 4 },
			// Index: 42
			new LevelListIndex() { SignificantCoeffFlagFrame = 14, SignificantCoeffFlagField = 10, LastSignificantCoeffFlag = 4 },
			// Index: 43
			new LevelListIndex() { SignificantCoeffFlagFrame = 10, SignificantCoeffFlagField = 10, LastSignificantCoeffFlag = 4 },
			// Index: 44
			new LevelListIndex() { SignificantCoeffFlagFrame = 9, SignificantCoeffFlagField = 8, LastSignificantCoeffFlag = 4 },
			// Index: 45
			new LevelListIndex() { SignificantCoeffFlagFrame = 8, SignificantCoeffFlagField = 13, LastSignificantCoeffFlag = 4 },
			// Index: 46
			new LevelListIndex() { SignificantCoeffFlagFrame = 6, SignificantCoeffFlagField = 13, LastSignificantCoeffFlag = 4 },
			// Index: 47
			new LevelListIndex() { SignificantCoeffFlagFrame = 11, SignificantCoeffFlagField = 9, LastSignificantCoeffFlag = 4 },
			// Index: 48
			new LevelListIndex() { SignificantCoeffFlagFrame = 12, SignificantCoeffFlagField = 9, LastSignificantCoeffFlag = 5 },
			// Index: 49
			new LevelListIndex() { SignificantCoeffFlagFrame = 13, SignificantCoeffFlagField = 10, LastSignificantCoeffFlag = 5 },
			// Index: 50
			new LevelListIndex() { SignificantCoeffFlagFrame = 11, SignificantCoeffFlagField = 10, LastSignificantCoeffFlag = 5 },
			// Index: 51
			new LevelListIndex() { SignificantCoeffFlagFrame = 6, SignificantCoeffFlagField = 8, LastSignificantCoeffFlag = 5 },
			// Index: 52
			new LevelListIndex() { SignificantCoeffFlagFrame = 9, SignificantCoeffFlagField = 13, LastSignificantCoeffFlag = 6 },
			// Index: 53
			new LevelListIndex() { SignificantCoeffFlagFrame = 14, SignificantCoeffFlagField = 13, LastSignificantCoeffFlag = 6 },
			// Index: 54
			new LevelListIndex() { SignificantCoeffFlagFrame = 10, SignificantCoeffFlagField = 9, LastSignificantCoeffFlag = 6 },
			// Index: 55
			new LevelListIndex() { SignificantCoeffFlagFrame = 9, SignificantCoeffFlagField = 9, LastSignificantCoeffFlag = 6 },
			// Index: 56
			new LevelListIndex() { SignificantCoeffFlagFrame = 11, SignificantCoeffFlagField = 10, LastSignificantCoeffFlag = 7 },
			// Index: 57
			new LevelListIndex() { SignificantCoeffFlagFrame = 12, SignificantCoeffFlagField = 10, LastSignificantCoeffFlag = 7 },
			// Index: 58
			new LevelListIndex() { SignificantCoeffFlagFrame = 13, SignificantCoeffFlagField = 14, LastSignificantCoeffFlag = 7 },
			// Index: 59
			new LevelListIndex() { SignificantCoeffFlagFrame = 11, SignificantCoeffFlagField = 14, LastSignificantCoeffFlag = 7 },
			// Index: 60
			new LevelListIndex() { SignificantCoeffFlagFrame = 14, SignificantCoeffFlagField = 14, LastSignificantCoeffFlag = 8 },
			// Index: 61
			new LevelListIndex() { SignificantCoeffFlagFrame = 10, SignificantCoeffFlagField = 14, LastSignificantCoeffFlag = 8 },
			// Index: 62
			new LevelListIndex() { SignificantCoeffFlagFrame = 12, SignificantCoeffFlagField = 14, LastSignificantCoeffFlag = 8 },
			// Index: 63
			new LevelListIndex() { SignificantCoeffFlagFrame = 0, SignificantCoeffFlagField = 0, LastSignificantCoeffFlag = 0 },
		};
	}
}

