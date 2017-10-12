/*
 * This "script" only contains notes to keep track of anything related to Time, as it is spread out and used across multiple scripts.
 * 
 * Stats
 * {
 *  public float Timer;
 *  public float CompletedTime;
 *  public bool TimeFreeze;
 * }
 * 
 * PlayerManager
 * {
 *  uses Timer = 0f;
 *  uses TimeFreeze; 
 * }
 *
 * HUD
 * {
 *  public Text TimeShow;
 *  
 *  TimeShow = "Time: " + Timer.ToString("F2");
 *  uses Timer += Time.deltaTime;
 *  
 *  uses TimeFreeze;
 * }
 */