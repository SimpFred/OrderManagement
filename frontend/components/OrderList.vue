<template>
  <div class="container mx-auto p-4">
    <div class="max-w-3xl mx-auto p-6">
      <div class="flex md:flex-row flex-col mb-6">
        <h1 class="text-3xl font-bold mb-6 text-center text-gray-800">
          Beställningar
        </h1>
        <div class="mb-6 flex max-md:mx-auto ml-auto items-center space-x-4">
          <input
            v-model="searchQuery"
            type="text"
            placeholder="Sök"
            class="w-full p-2 border border-gray-300 rounded-lg"
          />
          <select
            v-model="searchCriteria"
            class="p-2 border cursor-pointer border-gray-300 rounded-lg"
          >
            <option value="id">Order ID</option>
            <option value="name">Kundnamn</option>
            <option value="date">Datum</option>
          </select>
        </div>
      </div>
      <div class="space-y-4 max-w-3xl mx-auto">
        <OrderCard
          v-for="order in filteredOrders"
          :key="order.id"
          :order="order"
        />
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref, computed } from "vue";
import { useFetch } from "#app";
import type { Order } from "~/types";
import OrderCard from "~/components/OrderCard.vue";

const orders = ref<Order[]>([]);
const searchQuery = ref<string>("");
const searchCriteria = ref<string>("id");

const { data, error } = await useFetch<Order[]>(
  "http://localhost:5025/api/orders"
);

if (error.value) {
  console.error("Error fetching orders:", error.value);
} else {
  orders.value = data.value ?? [];
}

// Computed property to filter orders based on search query and criteria
const filteredOrders = computed(() => {
  return orders.value.filter((order) => {
    const query = searchQuery.value.toLowerCase();
    if (searchCriteria.value === "id") {
      return order.id.toString().includes(query);
    } else if (searchCriteria.value === "name") {
      return order.customer.name.toLowerCase().includes(query);
    } else if (searchCriteria.value === "date") {
      const formattedCreatedAt = formatDate(order.createdAt).toLowerCase();
      return formattedCreatedAt.includes(query);
    }
    return false;
  });
});
</script>
