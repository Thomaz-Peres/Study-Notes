using leetcode;

public static class Solution226 {
    public static TreeNode? InvertTree(TreeNode root) {
        if (root == null || root.left == null || root.right == null)
            return root;

        var newValue = InvertTree(root.left);

        var ol = root.right;
        root.right = newValue;
        root.left = ol;


        return root;
    }
}
