using leetcode;

public static class Solution226 {
    public static TreeNode? InvertTree(TreeNode root) {
        if (root == null)
            return root;

        var newLeft = InvertTree(root.left);
        var newRight = InvertTree(root.right);

        root.right = newLeft;
        root.left = newRight;

        return root;
    }
}
