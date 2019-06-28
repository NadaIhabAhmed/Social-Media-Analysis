#include <iostream>
#include <vector>
#include <set>
#include <climits>
using namespace std;

// Number of vertices in the graph
//#define V 9

int minDistance(vector<int> dist, vector<bool> sptSet, int v); // first mod
float dijkstra_closeness(vector <vector<int> > graph, int src, int v);


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
		adj_matrix[a][b] = c;
		adj_matrix[b][a] = c;
	}

		for (int i = 0; i < n; i++)
		{
			cout << (n - 1) / (dijkstra_closeness(adj_matrix, i, n)) << '\n';
		}
	
	return 0;
}

int minDistance(vector<int> dist, vector<bool> sptSet, int v)
{

	int min = INT_MAX, min_index;

	for (int w = 0; w < v; w++)
	{
		if (sptSet[w] == false && dist[w] <= min)
		{
			min = dist[w], min_index = w;
		}
	}
	return min_index;
}


float dijkstra_closeness(vector <vector<int> > graph, int src, int v)
{
	vector<int> dist(v, 0);
	vector<bool> sptSet(v, 0);

	for (int i = 0; i < v; i++)
	{
		dist[i] = INT_MAX, sptSet[i] = false;
	}

	dist[src] = 0;

	for (int count = 0; count < v - 1; count++)
	{
		int u = minDistance(dist, sptSet, v);

		sptSet[u] = true;

		for (int w = 0; w < v; w++)
		{
			if (!sptSet[w] && graph[u][w] && dist[u] != INT_MAX && dist[u] + graph[u][w] < dist[w])
			{
				dist[w] = dist[u] + graph[u][w];
			}
		}
	}
	float temp = 0;
	for (int i = 0; i < v; i++)
	{
		temp = temp + dist[i];
	}

	return temp;

}
