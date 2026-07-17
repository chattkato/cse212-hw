using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// Problem 1
    /// </summary>
    public static string[] FindPairs(string[] words)
    {
        var result = new List<string>();
        var wordSet = new HashSet<string>(words);

        foreach (var word in words)
        {
            var reversed = new string(new[] { word[1], word[0] });

            if (word == reversed)
                continue;

            if (wordSet.Contains(reversed) &&
                string.Compare(word, reversed) < 0)
            {
                result.Add($"{word} & {reversed}");
            }
        }

        return result.ToArray();
    }

    /// <summary>
    /// Problem 2
    /// </summary>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            var degree = fields[3];

            if (degrees.ContainsKey(degree))
            {
                degrees[degree]++;
            }
            else
            {
                degrees[degree] = 1;
            }
        }

        return degrees;
    }

    /// <summary>
    /// Problem 3
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();

        if (word1.Length != word2.Length)
            return false;

        var charCount = new Dictionary<char, int>();

        foreach (char c in word1)
        {
            if (charCount.ContainsKey(c))
                charCount[c]++;
            else
                charCount[c] = 1;
        }

        foreach (char c in word2)
        {
            if (!charCount.ContainsKey(c))
                return false;

            charCount[c]--;

            if (charCount[c] < 0)
                return false;
        }

        // Final verification that all counts are zero
        foreach (var count in charCount.Values)
        {
            if (count != 0)
                return false;
        }

        return true;
    }

    /// <summary>
    /// Problem 5
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri =
            "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";

        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);

        var json = reader.ReadToEnd();

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var featureCollection =
            JsonSerializer.Deserialize<FeatureCollection>(json, options);

        var result = new List<string>();

        if (featureCollection?.Features != null)
        {
            foreach (var feature in featureCollection.Features)
            {
                if (feature?.Properties != null)
                {
                    result.Add(
                        $"{feature.Properties.Place} - Mag {feature.Properties.Mag}"
                    );
                }
            }
        }

        return result.ToArray();
    }
} 