public class Solution733 {
    public static int[][] FloodFill(int[][] image, int sr, int sc, int color) {
        var current = image[sr][sc];
        if (current != color)
            Fill(image, sr, sc, current, color);

        return image;
    }

    private static void Fill(int[][] image, int sr, int sc, int oldColo, int newColor)
    {
        if (image[sr][sc] == oldColo)
        {
            image[sr][sc] = newColor;
            if (sr >= 1)
                Fill(image, sr - 1, sc, oldColo, newColor);

            if (sc >= 1)
                Fill(image, sr, sc - 1, oldColo, newColor);

            if (sr + 1 < image.Length)
                Fill(image, sr + 1, sc, oldColo, newColor);

            if (sc + 1 < image[0].Length)
                Fill(image, sr, sc + 1, oldColo, newColor);
        }
    }
}
