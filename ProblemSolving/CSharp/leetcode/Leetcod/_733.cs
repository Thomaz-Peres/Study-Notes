public static class Solution733 {
    public static int[][] FloodFill(int[][] image, int sr, int sc, int color) {
        var x = image[sr][sc];

        if (image[sr - 1][sc] == x)
            image[sr - 1][sc] = color;

        return image;
    }
}
