import requests

# Moedas
coins = ["bitcoin", "ethereum", "dogecoin"]

url = "https://api.coingecko.com/api/v3/simple/price"
params = {
    "ids": ",".join(coins),
    "vs_currencies": "usd"
}

response = requests.get(url, params=params)
data = response.json()

api_url = "http://localhost:5011/prices"

for coin in coins:
    price = data[coin]["usd"]

    payload = {
        "assetName": coin.capitalize(),
        "price": price
    }

    api_response = requests.post(api_url, json=payload)

    print(f"{coin}: enviado com sucesso →", api_response.status_code)