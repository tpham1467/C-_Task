//#include<iostream>
//using namespace std;
//struct node
//{
//	node* left;
//	node* right;
//	int data;
//	
//};
//node* createnode(int data)
//{
//	return new node
//	{
//	
//	nullptr,
//	nullptr,
//	data
//	};
//}
//int getheight(node* root) {
//	if (root == nullptr)
//		return 0;
//	return 1 + max(getheight(root->left), getheight(root->right));
//	
//}
//node* left(node* root)
//{
//	node* y = root->right;
//
//	// Bắt đầu quay trái
//	root->right = y->left;
//	y->left = root;
//	return y;
//}
//node* right(node* root)
//{
//	node* x = root->left;
//
//	root->left = x->right;
//	x->right = root;
//	return x;
//}
//node* insert(node* root, int data)
//{
//	if (root == nullptr) return createnode(data);
//	if (root->data > data)
//	{
//		root->left = insert(root->left, data);
//	}
//	else if (root->data < data)
//	{
//		root->right = insert(root->right, data);
//	}
//	else
//	{
//		return root;
//	}
//	int valBalance = getheight(root->left) - getheight(root->right);
//
//	// Kiểm tra 4 TH xảy ra:
//	// 3.1. Left left
//	if (valBalance > 1 && data < root->left->data)
//		return right(root);
//
//	// 3.2. Right Right
//	if (valBalance < -1 && data > root->right->data)
//		return left(root);
//
//	// 3.3. Left Right
//	if (valBalance > 1 && data > root->left->data) {
//		root->left = left(root->left);
//		return right(root);
//	}
//
//	// 3.4. Right Left
//	if (valBalance < -1 && data < root->right->data) {
//		root->right = right(root->right);
//		return left(root);
//	}
//	return root;
//}
//
//void print2DUtil(node* root, int space) {
//	if (root == NULL)
//		return;
//	space += 10;
//
//	print2DUtil(root->right, space);
//	cout << endl;
//
//	for (int i = 10; i < space; i++)
//		cout << " ";
//	cout << root->data << " (" << getheight(root) << ") " << "\n";
//
//	print2DUtil(root->left, space);
//}
//int main()
//{
//	node* tree = nullptr;
//	tree = insert(tree, 18);
//	tree = insert(tree, 12);
//	tree = insert(tree, 30);
//	tree = insert(tree, 25);
//	tree = insert(tree, 69);
//	print2DUtil(tree, 0);
//	cout << endl<<endl<<endl;
//	tree = insert(tree, 23);
//	print2DUtil(tree,0);
//
//}