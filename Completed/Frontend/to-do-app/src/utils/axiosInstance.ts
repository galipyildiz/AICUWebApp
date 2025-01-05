import axios from "axios";

export const axiosInstance = axios.create({
  baseURL: "https://localhost:44366/api", //api temel url,
  timeout: 5000, // İsteğin zaman aşımı süresi (ms)
  headers: {
    "Content-Type": "application/json", //JSON formatı veri gönderimi
    // Authorization: "token" // authorize endpointler için
  },
});
