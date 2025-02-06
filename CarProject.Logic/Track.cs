namespace CarProject.Logic;

public class Track
{
  #region field
  private readonly List<Section> _trackList;
  private readonly bool _loopedTrack;
  #endregion

  #region constructor
  public Track(List<Section>? trackList , bool trackShallLoop = false)
  {
    if (trackList == null || trackList.Count == 0)
      throw new ArgumentNullException(nameof(trackList));

        _trackList = trackList; 
        _loopedTrack = trackShallLoop;

        if (LoopedTrack)
            _trackList.Last().AddAfterMe(_trackList.First());
  }
  #endregion

  #region properties
  public Section? StartSection { get => _trackList.FirstOrDefault(); }

  public int GetTotalLenght
  {
    get
    {
      int result = 0;

      foreach (var section in _trackList)
        result += section.Length;

      return result;
    }
  }

  public int GetMaxSpeed
  {
    get
    {
      int result = 0;

      foreach (var section in _trackList)
        if (section.MaxSpeed > result)
          result = section.MaxSpeed;

      return result;
    }
  }

  public bool LoopedTrack => _loopedTrack;
  #endregion


  public void Debug_PrintSection(int index)
  {
    if (_trackList.Count == 0)
      Console.WriteLine("Your Track is empty");
    else if (index == -1)
    {
      int i = 0;
      foreach (var section in _trackList)
        Debug_PrintSection(i++);
    }
    else if (index >= _trackList.Count || index < 0)
      Console.WriteLine("Index out of Range");
    else
      Console.WriteLine(_trackList[ index ].ToString());
  }
}
