import requests, os, sys

model_id = '98d753c0-3466-4eff-a7a5-c60ec466caab'
api_key = 'z-YHZH2s1ANZi4adh9_lUfNGt1P9joCu'

url = 'https://app.nanonets.com/api/v2/ObjectDetection/Model/' + model_id + '/Train/'

querystring = {'modelId': model_id}

response = requests.request('POST', url, auth=requests.auth.HTTPBasicAuth(api_key, ''), params=querystring)

print(response.text)

f = open("status.txt", "w")
f.write(response.text)
f.close()

print("\n\nNEXT RUN: python ./code/model-state.py")