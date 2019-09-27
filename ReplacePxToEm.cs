public string ReplacePxToEm(string htmlText)
{
    var regExp = @"\d*\.?\d+(?:px;|%)";

    StringBuilder sb = new StringBuilder(htmlText);
    MatchCollection matchList = Regex.Matches(htmlText, regExp);
    var pxItems = matchList.Cast<Match>().Select(match => match.Value).ToList();
    foreach (var px in pxItems)
    {
        double ptDouble = Convert.ToDouble(px.Replace("px;", ""));
        double emDouble = Math.Round((ptDouble / 16), 3);
        var em = $"{emDouble}em;";
        sb.Replace(px, em);
    }
    return sb.ToString();
}
