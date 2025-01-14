<template>
  <div class="container mx-auto p-6 max-w-5xl">
    <div class="bg-slate-100 shadow-md rounded-lg p-6">
      <h1 class="text-3xl font-bold mb-10 text-left text-gray-800">
        Order Detaljer
      </h1>
      <div v-if="order">
        <div class="flex flex-col sm:flex-row mb-6">
          <OrderInfo :order="order" />
          <CustomerInfo :order="order" />
        </div>
        <ProductList :order="order" />
      </div>
      <div v-else>
        <p class="text-center text-gray-500">Laddar...</p>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { useRoute } from "vue-router";
import { useAsyncData } from "#app";
import type { Order } from "~/types";
import OrderInfo from "~/components/OrderInfo.vue";
import CustomerInfo from "~/components/CustomerInfo.vue";
import ProductList from "~/components/ProductList.vue";

const route = useRoute();
const orderId = Number(route.params.id);

const { data: order, error } = await useAsyncData<Order>(
  `order-${orderId}`,
  () =>
    fetch(`http://localhost:5025/api/orders/${orderId}`).then((res) =>
      res.json()
    )
);

console.log("Order details:", order);

if (error.value) {
  console.error("Error fetching order details:", error.value);
}
</script>
