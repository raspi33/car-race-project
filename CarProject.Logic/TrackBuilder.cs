namespace CarProject.Logic;

public class TrackBuilder
{
    #region field
    private readonly (int, int)[] _sectionInfos;
    private readonly Track? _track;
    #endregion

    #region property
    public Track? RaceTrack => _track;
    #endregion

    #region constructor
    public TrackBuilder((int, int)[] sectionInfos, bool trackShallLoop = false)
    {
        _sectionInfos = sectionInfos;

        List<Section> allSections = new();
        Section? lastSection = null;


        foreach (var section in _sectionInfos)
        {
            Section newSection = new(section.Item1, section.Item2);


            if (lastSection != null)
            {
                lastSection.AddAfterMe(newSection);
            }

            lastSection = newSection;
            allSections.Add(newSection);

            if (trackShallLoop && allSections.Count > 1)
            {
                allSections[^1].AddAfterMe(allSections[0]);
            }
        }

        _track = new Track(allSections, trackShallLoop);
    }
    #endregion
}
