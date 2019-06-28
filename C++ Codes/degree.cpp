#include <iostream>
#include <vector>
#include <set>
#include <climits>


using namespace std;




int main()
{
	int n, m;
	cin >> n >> m;
	vector <vector<int> > adj_matrix(n, vector<int>(n, 0));
	vector <int> count;
	int a, b, c;
	for (int i = 0; i < m; i++)
	{
		cin >> a >> b >> c;
		adj_matrix[b][a] = c;
		adj_matrix[a][b] = c;
	}

		for (int i = 0; i < n; i++)
		{
			int counter = 0;
			for (int j = 0; j < n; j++)
			{
				if (adj_matrix[i][j] != 0)
					counter++;
			}
			count.push_back(counter);
		}

		for (int i = 0; i < n; i++)    // check the degree
		{
			cout << count[i] << '\n';
		}
	


	return 0;
}
