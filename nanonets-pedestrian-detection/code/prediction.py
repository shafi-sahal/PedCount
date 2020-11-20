import requests, os, sys

model_id = '98d753c0-3466-4eff-a7a5-c60ec466caab'
api_key = 'z-YHZH2s1ANZi4adh9_lUfNGt1P9joCu'
image_path = sys.argv[1]

url = 'https://app.nanonets.com/api/v2/ObjectDetection/Model/' + model_id + '/LabelFile/'

data = {'file': open(image_path, 'rb'),    'modelId': ('', model_id)}

response = requests.post(url, auth=requests.auth.HTTPBasicAuth(api_key, ''), files=data)

f = open("result.txt", "w")
f.write(response.text)
f.close()

print(response.text)
