public static class Solution733 {
    public static int[][] FloodFill(int[][] image, int sr, int sc, int color) {
        if (sr < 0 || sc < 0 && sr > image.Length)
            return image;

        image[sr][sc] = color;
        FloodFill(image, sr - 1, sc, color);
        FloodFill(image, sr + 1, sc, color);

        return image;
    }
}
