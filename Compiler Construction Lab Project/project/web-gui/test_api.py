import requests
import json

code = """int main() {
    int a;
    a = 10;
    output(a);
    return 0;
}"""

response = requests.post('http://localhost:5000/compile', json={'code': code})
print(json.dumps(response.json(), indent=2))
