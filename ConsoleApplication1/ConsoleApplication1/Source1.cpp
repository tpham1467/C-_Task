#include<iostream>
using namespace std;
#define COUNT 10
struct Node {
    int data;
    Node* left;
    Node* right;
    Node* parent;
    bool color;
    //1 -> Red   | 0 -> Black
};
struct RedBlackTree {
    Node* Root;
    RedBlackTree() {
        Root = nullptr;
    }
    Node* insertHelp(Node* root, int key) {
        if (root == nullptr) {
            // Luôn luôn thêm node đỏ
            return new Node{ key, nullptr, nullptr, nullptr, 1 }; // RED Node
        }
        else if (root != nullptr && key < root->data) {
            // Node X : root->left
            // X->parent : root 
            root->left = insertHelp(root->left, key);
            root->left->parent = root;
        }
        else {
            // Node X    : root->right
            // X->parent : root
            root->right = insertHelp(root->right, key);
            root->right->parent = root;
        }
        return root;
    }

    void Insert(int key) {
        if (Root == nullptr) {
            // Root luôn màu đen
            Root = new Node{ key, nullptr, nullptr, nullptr, 0 };
        }
        else {
            Root = insertHelp(Root, key);
            if (Root->color == 1)
                Root->color = 0;
        }
    }
};
string getColor(Node* root) {
    if (root->color == 1)
        return "RED";
    return "BLACK";
}
void print2DUtil(Node* root, int space) {
    if (root == NULL)
        return;
    space += COUNT;

    print2DUtil(root->right, space);
    cout << endl;

    for (int i = COUNT; i < space; i++)
        cout << " ";
    cout << root->data << " (" << getColor(root) << ") " << "\n";

    print2DUtil(root->left, space);
}

void print2D(Node* root) {
    print2DUtil(root, 0);
}
int main()
{
    RedBlackTree RBTree;
    RBTree.Insert(1);
    RBTree.Insert(4);
    RBTree.Insert(6);
    RBTree.Insert(3);
    RBTree.Insert(5);
    RBTree.Insert(7);
    RBTree.Insert(8);
    RBTree.Insert(2);
    RBTree.Insert(9);

    print2D(RBTree.Root);
}
